using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Nivel1.Data.UnitOfWork.Interfaces;
using Nivel1.Domain.ExternalServices.Marvel.Interfaces;
using Nivel1.Domain.ExternalServices.Marvel.Models;
using Nivel1.Domain.ExternalServices.Models;
using Nivel1.Shared;
using Nivel1.Shared.Configuration;
using Nivel1.Shared.Models;
using Nivel1.Shared.Models.Interfaces;

namespace Nivel1.Domain.ExternalServices.Marvel
{
    public class ComicExternalService : IComicExternalService
    {
        protected readonly MarvelComicsAPIConfig _marvelConfig;
        protected readonly IUnitOfWork _unitOfWOrk;

        public ComicExternalService(
            IOptions<MarvelComicsAPIConfig> MarvelConfig,
            IUnitOfWork unitOfWOrk
        )
        {
            _marvelConfig = MarvelConfig.Value;
            _unitOfWOrk = unitOfWOrk;
        }

        public async Task<IResultResponse<IList<Comic>>> Initialize()
        {
            IResultResponse<IList<Comic>> resultResponse = new ResultResponse<IList<Comic>>();
            IList<Comic> comics = new List<Comic>();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json")
                );

                HttpResponseMessage response = client.GetAsync(GetUrl()).Result;

                response.EnsureSuccessStatusCode();
                string result =
                    response.Content.ReadAsStringAsync().Result;

                dynamic resultado = JsonConvert.DeserializeObject(result);

                foreach (var item in resultado.data.results)
                {
                    bool exist = await ExistComic(item);
                    if (exist)
                    {
                        continue;
                    }

                    Comic comic = await CreateComic(item);
                    IList<Character> characters = await CreateCharacter(item);
                    IList<Creator> creators = await CreateCreator(item);
                    await CreateComicCharacter(characters, comic);
                    await CreateComicCreator(creators, comic);

                    await _unitOfWOrk.SaveChange();
                }



                resultResponse.Value = comics;

                return resultResponse;
            }
        }

        private Character GetCharacter(string Url)
        {
            Character character = new Character();

            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync(GetUrl(Url)).Result;

                response.EnsureSuccessStatusCode();
                string result = response.Content.ReadAsStringAsync().Result;
                dynamic resultJson = JsonConvert.DeserializeObject(result);

                character.Code = resultJson.data.results[0].id;
                character.Name = resultJson.data.results[0].name;
                character.UrlImage =
                    string.Concat(resultJson.data.results[0].thumbnail.path, ".", resultJson.data.results[0].thumbnail.extension);
                character.UrlWiki = resultJson.data.results[0].urls[1].url;
            }

            return character;
        }

        private int GetCodeCreator(string Url)
        {
            int Code = 0;

            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync(GetUrl(Url)).Result;

                response.EnsureSuccessStatusCode();
                string result = response.Content.ReadAsStringAsync().Result;
                dynamic resultJson = JsonConvert.DeserializeObject(result);

                Code = resultJson.data.results[0].id;
            }

            return Code;
        }

        private string GetUrl()
        {
            string ticks = DateTime.Now.Ticks.ToString();
            string hash = HashCreator.Create(ticks, _marvelConfig.PublicKey, _marvelConfig.PrivateKey);

            return string.Concat(_marvelConfig.BaseURL, $"comics?ts={ticks}&apikey={_marvelConfig.PublicKey}&hash={hash}");
        }

        private string GetUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return "";

            string ticks = DateTime.Now.Ticks.ToString();
            string hash = HashCreator.Create(ticks, _marvelConfig.PublicKey, _marvelConfig.PrivateKey);

            return string.Concat(url, $"?ts={ticks}&apikey={_marvelConfig.PublicKey}&hash={hash}");
        }

        private async Task<bool> ExistComic(dynamic item)
        {
            Comic comicExist = await _unitOfWOrk.ComicRepository.GetByCode(Convert.ToInt32(item.id));

            if (comicExist != null && comicExist.ComicID != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private async Task<Comic> CreateComic(dynamic item)
        {
            Comic comic = new Comic();
            comic.Code = item.id;
            comic.Title = item.title;
            comic.UrlWiki = string.Concat(item.thumbnail.path, ".", item.thumbnail.extension);
            comic.Ean = item.ean;
            comic.PageCount = item.pageCount;

            await _unitOfWOrk.ComicRepository.Add(comic);

            return comic;
        }

        private async Task<IList<Character>> CreateCharacter(dynamic item)
        {
            IList<Character> characters = new List<Character>();
            foreach (var characterItem in item.characters.items)
            {
                Character character = GetCharacter(characterItem.resourceURI.Value);
                Character characterExist = await _unitOfWOrk.CharacterRepository.GetByCode(character.Code);

                if (characterExist == null)
                {
                    await _unitOfWOrk.CharacterRepository.Add(character);
                    characters.Add(character);
                }
                else
                {
                    characters.Add(characterExist);
                }
            }

            return characters;
        }

        private async Task<IList<Creator>> CreateCreator(dynamic item)
        {
            IList<Creator> creators = new List<Creator>();
            foreach (var creatorItem in item.creators.items)
            {
                Creator creator = new Creator()
                {
                    Name = creatorItem.name,
                    Role = creatorItem.role,
                    Code = GetCodeCreator(creatorItem.resourceURI.Value)
                };

                Creator creatorExist = await _unitOfWOrk.CreatorRepository.GetByCode(creator.Code);

                if (creatorExist == null)
                {
                    await _unitOfWOrk.CreatorRepository.Add(creator);
                    creators.Add(creator);
                }
                else
                {
                    creators.Add(creatorExist);
                }
            }

            return creators;
        }

        private async Task CreateComicCharacter(IList<Character> characters, Comic comic)
        {
            IList<ComicCharacter> comicCharacters = new List<ComicCharacter>();

            foreach (var item in characters)
            {
                ComicCharacter comicCharacterItem = new ComicCharacter();
                comicCharacterItem.Character = item;
                comicCharacterItem.Comic = comic;

                comicCharacters.Add(comicCharacterItem);
            }

            await _unitOfWOrk.ComicCharacterRepository.Add(comicCharacters);
        }

        private async Task CreateComicCreator(IList<Creator> creators, Comic comic)
        {
            IList<ComicCreator> comicCreators = new List<ComicCreator>();

            foreach (var item in creators)
            {
                ComicCreator comicCreatorItem = new ComicCreator();
                comicCreatorItem.Comic = comic;
                comicCreatorItem.Creator = item;

                comicCreators.Add(comicCreatorItem);
            }

            await _unitOfWOrk.ComicCreatorRepository.Add(comicCreators);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Nivel1.Domain.ExternalServices.Marvel.Interfaces;
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

        public ComicExternalService(IOptions<MarvelComicsAPIConfig> MarvelConfig)
        {
            _marvelConfig = MarvelConfig.Value;
        }

        public IResultResponse<IList<Comic>> Get()
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
                    Comic comic = new Comic();
                    comic.Id = item.id;
                    comic.Title = item.title;
                    comic.UrlWiki = string.Concat(item.thumbnail.path, ".", item.thumbnail.extension);
                    comic.Ean = item.ean;
                    comic.PageCount = item.pageCount;

                    foreach (var characterItem in item.characters.items)
                    {
                        comic.Characters.Add(GetCharacter(characterItem.resourceURI.Value));
                    }

                    foreach (var creator in item.creators.items)
                    {
                        comic.Creators.Add(
                            new Creator()
                            {
                                Name = creator.name,
                                Role = creator.role
                            }
                        );
                    }

                    comics.Add(comic);
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

                character.Id = resultJson.data.results[0].id;
                character.Name = resultJson.data.results[0].name;
                character.UrlImage =
                    string.Concat(resultJson.data.results[0].thumbnail.path, ".", resultJson.data.results[0].thumbnail.extension);
                character.UrlWiki = resultJson.data.results[0].urls[1].url;
            }

            return character;
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
    }
}
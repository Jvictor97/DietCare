using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Clarifai.API;
using Clarifai.API.Responses;
using Clarifai.DTOs.Inputs;

namespace DietCareDDD.API.Clarifai
{
    public class ClarifaiCall
    {
        public static async Task<string> Predict(byte[] byteImage)
        {
            var client = new ClarifaiClient("d7b04a99342b4c9ea11f5f127879583f");

            var res = await client.PublicModels.FoodModel.Predict(
                    new ClarifaiFileImage(byteImage))
                .ExecuteAsync();

            return res.RawBody;
            // Print the concepts
            //foreach (var concept in res.Get().Data)
            //{
            //    Console.WriteLine($"{concept.Name}: {concept.Value}");
            //}
        }
    }
}

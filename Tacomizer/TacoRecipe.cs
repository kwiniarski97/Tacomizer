using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using RestSharp;
using RestSharp.Deserializers;
using Tacomizer.Model;

namespace Tacomizer
{
    [Activity(Label = "Recipe")]
    public class TacoRecipe : Activity
    {
        private TextView _baseLayerTitle;
        private TextView _baseLayerBody;
        private TextView _mixinTitle;
        private TextView _mixinBody;
        private TextView _condimentTitle;
        private TextView _condimentBody;
        private TextView _seasoningTitle;
        private TextView _seasoningBody;
        private TextView _shellTitle;
        private TextView _shellBody;
        private Response _response;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.TacoRecipe);

            this._response = GetResponse();
            Title = _response.base_layer.name;
            WireUI();
            SetUIValues();

        }

        private Response GetResponse()
        {
            var json = Intent.GetStringExtra("ResponseJson");
            var fakeResponse = new RestResponse {Content = json};
            var deserializer = new JsonDeserializer();
            var response = deserializer.Deserialize<Response>(fakeResponse);
            return response;
        }

        private void WireUI()
        {
            this._baseLayerTitle = FindViewById<TextView>(Resource.Id.taco_recipe_baselayer_title);
            this._baseLayerBody = FindViewById<TextView>(Resource.Id.taco_recipe_baselayer_body);
            this._mixinTitle = FindViewById<TextView>(Resource.Id.taco_recipe_mixin_title);
            this._mixinBody = FindViewById<TextView>(Resource.Id.taco_recipe_mixin_body);
            this._condimentTitle = FindViewById<TextView>(Resource.Id.taco_recipe_condiment_title);
            this._condimentBody = FindViewById<TextView>(Resource.Id.taco_recipe_condiment_body);
            this._seasoningTitle = FindViewById<TextView>(Resource.Id.taco_recipe_seasoning_title);
            this._seasoningBody = FindViewById<TextView>(Resource.Id.taco_recipe_seasoning_body);
            this._shellTitle = FindViewById<TextView>(Resource.Id.taco_recipe_shell_title);
            this._shellBody = FindViewById<TextView>(Resource.Id.taco_recipe_shell_body);
        }

        private void SetUIValues()
        {
            SetBaseLayerViews();
            SetMixinViews();
            SetCondimentViews();
            SetSeasoningViews();
            SetShellViews();
        }

        private void SetBaseLayerViews()
        {
            this._baseLayerTitle.Text = _response.base_layer.name;
            this._baseLayerBody.Text = RemoveUnnecesaryPartsFromRecipe(_response.base_layer.recipe);
        }

        private void SetMixinViews()
        {
            this._mixinTitle.Text = _response.mixin.name;
            this._mixinBody.Text = RemoveUnnecesaryPartsFromRecipe(_response.mixin.recipe);
        }

        private void SetCondimentViews()
        {
            this._condimentTitle.Text = _response.condiment.name;
            this._condimentBody.Text = RemoveUnnecesaryPartsFromRecipe(_response.condiment.recipe);
        }

        private void SetSeasoningViews()
        {
            this._seasoningTitle.Text = _response.seasoning.name;
            this._seasoningBody.Text = RemoveUnnecesaryPartsFromRecipe(_response.seasoning.recipe);
        }

        private void SetShellViews()
        {
            this._shellTitle.Text = _response.shell.name;
            this._shellBody.Text = RemoveUnnecesaryPartsFromRecipe(_response.shell.recipe);
        }

        private string RemoveUnnecesaryPartsFromRecipe(string recipe)
        {
            //todo wymysl jak to zrobic 
            return recipe;
        }
    }
}
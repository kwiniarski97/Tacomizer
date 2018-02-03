using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;
using RestSharp.Serializers;
using Tacomizer.Controller;
using Tacomizer.Extensions;
using Tacomizer.Model;

namespace Tacomizer
{
    [Activity(Label = "Taconizer")]
    public class TacoNameVoteActivity : Activity
    {
        private TextView _title;
        private Button _likeButton;
        private Button _unlikeButton;
        private Response _response;
       
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.TacoNameVote);
            WireUI();
            BindListeners();
            this._response = await GetTacoResponse();
            SetTitleFromResponse(_response);
        }

        private void BindListeners()
        {
            this._likeButton.Click += (sender, args) =>
            {
                if(_response.IsNull())
                {
                    Toast.MakeText(this, "Couldn't load a response", ToastLength.Long);
                }
                else
                {
                    var responseJson = JsonifyCurrentResponse();
                    var tacoRecipe = new Intent(this,typeof(TacoRecipe));
                    tacoRecipe.PutExtra("ResponseJson", responseJson);
                    StartActivity(tacoRecipe);
                }
                
            };
            this._unlikeButton.Click += (sender, args) => { Recreate(); };
        }

        private string JsonifyCurrentResponse()
        {
            JsonSerializer serializer = new JsonSerializer();
            return serializer.Serialize(_response);
        }

        private void WireUI()
        {
            this._title = FindViewById<TextView>(Resource.Id.taco_vote_title);
            this._likeButton = FindViewById<Button>(Resource.Id.taco_vote_like);
            this._unlikeButton = FindViewById<Button>(Resource.Id.taco_vote_unlike);
        }

        private async Task<Response> GetTacoResponse()
        {
            return await TacoController.GetRandomTaco();
        }

        private void SetTitleFromResponse(Response response)
        {
            var sb = new StringBuilder();
            sb.Append(response.base_layer.name.ToUpperFirstLetter());
            sb.Append(" with ");
            sb.Append(response.mixin.name);
            sb.Append(", garnished with ");
            sb.Append(response.condiment.name);
            sb.Append(" topped off with ");
            sb.Append(response.seasoning.name);
            sb.Append(" and wrapped in delicious ");
            sb.Append(response.shell.name);
            this._title.Text = sb.ToString();
            var view = FindViewById(Resource.Id.loadingPanel);
            view.Visibility = ViewStates.Gone;
        }
    }
}
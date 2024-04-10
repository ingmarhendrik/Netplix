using CommunityToolkit.Mvvm.ComponentModel;
using Models;
using Netplix.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Netplix.ViewModels
{
    public partial class HomeViewModel: ObservableObject
    {
        private readonly TmdbService _tmdbService;
        public HomeViewModel(TmdbService tmdbService)
        {
            _tmdbService = tmdbService;
        }

        [ObservableProperty]
        private Media  _trendingMovie;

        public ObservableCollection<Media> Trending { get; set; } = new();
        public ObservableCollection<Media> Toprated { get; set; } = new();
        public ObservableCollection<Media> NetflixOriginals { get; set; } = new();
        public ObservableCollection<Media> ActionMovies { get; set; } = new();
        public async Task InitializeAsync()
        {
            var trendingList = await _tmdbService.GetTrendingAsync();
            if (trendingList?.Any() == true)
            {
                foreach (var trending in trendingList)
                {
                    Trending.Add(trending);
                }
            }
        }
    
    }
}

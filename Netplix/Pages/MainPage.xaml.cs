using Netplix.Services;

namespace Netplix.Pages;

public partial class MainPage : ContentPage
{
	private readonly TmdbService _tmdbService;
	int count = 0;
	public MainPage(TmdbService tmdbService)
	{
		InitializeComponent();
		_tmdbService = tmdbService;
	}

    protected async override void OnAppearing()
    {
        base.OnAppearing();
		var trneding = await _tmdbService.GetTrendingAsync();
    }

}
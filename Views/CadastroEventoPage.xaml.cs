
using CadastroEventos.Models;

namespace CadastroEventos.Views;

public partial class CadastroEventoPage : ContentPage
{
    private Evento evento;

    public CadastroEventoPage()
    {
        InitializeComponent();

        evento = new Evento();

        BindingContext = evento;
    }

    private async void CadastrarEvento_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(evento.Nome) ||
            string.IsNullOrWhiteSpace(evento.Local) ||
            evento.NumeroParticipantes <= 0 ||
            evento.CustoPorParticipante <= 0)
        {
            await DisplayAlert("Atenção",
                "Preencha todos os campos corretamente.", "OK");

            return;
        }

        if (evento.DataTermino.Date < evento.DataInicio.Date)
        {
            await DisplayAlert("Atenção",
                "A data de término não pode ser anterior à data de início.", "OK");

            return;
        }

        await Navigation.PushAsync(new ResumoEventoPage(evento));
    }
}

$('#fetchBtn').on('click', function (event) {
    event.preventDefault();

    $.ajax({
        url: '@Url.Action("FetchPokemonList", "Home")',
        type: 'POST',
        data: { pokemonNames: $('#pokemonNames').val() },
        success: function (result) {
            $('#pokemonListContainer').html(result);
        },
        error: function () {
            $('#pokemonListContainer').html('<p>There was an error. Please try again.</p>');
        }
    });
});
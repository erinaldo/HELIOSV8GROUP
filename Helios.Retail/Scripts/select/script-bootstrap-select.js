var pes = jQuery.noConflict();
var Jquery102 = pes;//$.fn.jquery;
$(document).ready(function () 
{
    // Enable Live Search.
    Jquery102('#CountryList').attr('data-live-search', true);

    Jquery102('.selectCountry').selectpicker(
    {
        width: '100%',
        title: '- [Seleccionar Mesa] -',
        style: 'btn-warning',
        size: 6
        });

    Jquery102('.selectOrder').selectpicker(
        {
            width: '100%',
            title: '- [Seleccionar Mesa] -',
            style: 'btn-danger',
            size: 6
        });
});  


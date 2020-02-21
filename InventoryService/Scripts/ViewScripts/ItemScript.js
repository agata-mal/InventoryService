$(document).ready(() => {
    this.ItemValidation();
    $('#ItemNumber').change(() => {
        this.CheckItemNumberAvailability();
    });

});


function ItemValidation() {
    $.validator.addMethod('ItemNumberRule', () => {
        return Number($('#ItemNumber').val()) > 0 && Number($('#ItemNumber').val()) < 10000;
    }, "Kod produktu musi być w zakresie 1-9999");

    $('#ItemNumber').addClass('ItemNumberRule');


    $.validator.addMethod('ExpectedAmountRule', () => {
        var expectedAmount = $('#ExpectedAmount').val().replace(',', '.');
        if (Number($('#Unit').val()) === 1) {

            return Number.isInteger(Number(expectedAmount));
        } return true;
    }, "Oczekiwana ilość produktu \"szt\" musi być liczbą całkowią");
    $('#ExpectedAmount').addClass('ExpectedAmountRule');



}
function CheckItemNumberAvailability() {
    
    $.ajax(
        {
            type: 'POST',
            url: '/Item/CheckItemNumber',
            data: {
                productCode: Number($('#ItemNumber').val())
            },
            success: (responseData) => {
                if (responseData.Response === 'True') {
                    alert('Ten produkt już istnieje!');
                }
            }


        })
}


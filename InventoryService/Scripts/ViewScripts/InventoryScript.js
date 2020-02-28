$(document).ready(() => {
    $('.glyphicon-ok').click(() => {
        var idValue = $(event.target).data('href');
        var elementName = '#realAmount' + idValue;
        $.ajax(
            {
                type: 'POST',
                url: '/Inventory/SaveRealAmount',
                data: {
                    id: Number(idValue),
                    realAmount: $(elementName).val()
                },
                success: (data) => {
                    if (data === 'OK') {
                        alert('Zapisano poprawnie');
                    }
                    else {
                        alert('Zapisywanie nie powiodło się');
                    }
                }


            })
    })
})
document.addEventListener('DOMContentLoaded', function() {

    const bookButton = document.getElementById('tobook');
    
    const form = document.getElementById('reservationForm');
    
    bookButton.addEventListener('click', function(event) {
        event.preventDefault();
        
      
        const room = document.getElementById('selectRoom').value;
        const bookerName = document.getElementById('validationBookerName').value;
        const bookDate = document.getElementById('validationBookDate').value;

        if (!room || !bookerName || !bookDate) {
            alert("Por favor, complete todos los campos.");
            return;
        }
        //'@Url.Action("Reservar", "Home")' solo se usa con las vistas Razor es decir cuando el script esta en el html directo en .net
        // como se se decide sesaclopar en js se deja como string 
        var url = '/Reserva/Reservar';
        console.log(url);
        console.log('Room:',room);
        console.log('BookerName:',bookerName);
        console.log('BookDate:',bookDate);
        fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                IdSala: room,
                Reservador: bookerName,
                FechaReserva: bookDate
            })
        })
        .then(response => response.json())
        .then(data => {
            if (data.success) {
                alert("¡Reserva realizada con éxito!");
                //window.location.href = '@Url.Action("Confirmacion", "Reserva")'; 
            } else {
                alert("Hubo un error en la reserva.");
            }
        })
        .catch(error => {
            console.error('Error:', error);
            alert("Hubo un problema al procesar la reserva.");
        });
    });
});

document.addEventListener('DOMContentLoaded', function() {

    const bookButton = document.getElementById('toroom');
    
    const form = document.getElementById('newRoomForm');
    
    bookButton.addEventListener('click', function(event) {
        event.preventDefault();
        
      
        const roomName = document.getElementById('validationRoomName').value;
        const roomCapacity = document.getElementById('validationRoomCapacity').value;
        

        if (!roomName || !roomCapacity) {
            alert("Por favor, complete todos los campos.");
            return;
        }
        //'@Url.Action("Reservar", "Home")' solo se usa con las vistas Razor es decir cuando el script esta en el html directo en .net
        // como se se decide sesaclopar en js se deja como string 
        var url = '/Sala/Agregar';
        console.log(url);
        console.log('RoomName:',roomName);
        console.log('RoomCapacity:',roomCapacity);
        fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                Nombre: roomName,
                Capacidad: roomCapacity
                
            })
        })
        .then(response => response.json())
        .then(data => {
            if (data.success) {
                alert("¡Sala creada con éxito!");
                //window.location.href = '@Url.Action("agregar", "sala")'; 
            } else {
                alert("Hubo un error en la creación de la sala.");
            }
        })
        .catch(error => {
            console.error('Error:', error);
            alert("Hubo un problema al procesar la solicitud de la sala.");
        });
    });
});

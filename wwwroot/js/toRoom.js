document.addEventListener('DOMContentLoaded', function() {

    /* VARIABLES DOM      */
    const saveroomButton = document.getElementById('toroom');
    const getroomButton = document.getElementById('togetroom');
    const formRoom = document.getElementById('newRoomForm');

    /* METODOS */
    function GetAllSalas(){
        // Obtiene el contenedor de salas y muestra un mensaje de carga
        const salasContainer = document.getElementById("salasContainer");
        salasContainer.innerHTML=``;
        
        var url = '/Sala/ObtenerSalas';
        console.log("Llamada a URL:", url);
        
        fetch(url, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            }
        })
        .then(response => response.json())
        .then(data => {
            if (data.success) {
                console.log("¡Salas obtenidas!");
                data.data.forEach((sala,index) => {
                    const row = document.createElement('tr');
                    row.innerHTML = `
                    <tr>
                        <td>${index+1}</td>
                        <td>${sala.nombre}</td>
                        <td>${sala.capacidad}</td>
                        <td>${sala.dispo ? "Sí" : "No"}</td>
                    </tr>
                    `;
                    salasContainer.append(row);
                });
             
            } else {
                alert("Hubo un error en la obtención de salas.");
            }
        })
        .catch(error => {
            console.error('Error:', error);
            alert("Hubo un problema al procesar la solicitud de obtener salas.");
        });
    }
    function CleanSalasForm(){
        formRoom.reset();
    }

    /* LISTENERS */
    getroomButton.addEventListener('click', function(event) {
        event.preventDefault();
        GetAllSalas()
    });

    saveroomButton.addEventListener('click', function(event) {
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
                GetAllSalas();
                CleanSalasForm();
            } else {
                alert("Hubo un error en la creación de la sala.");
            }
        })
        .catch(error => {
            console.error('Error:', error);
            alert("Hubo un problema al procesar la solicitud de la sala.");
        });
    });

    /* INICIALIZACIONES */
    GetAllSalas();
});

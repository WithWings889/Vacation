const uri = 'api/Transports';
let transports = [];


function _displayTransports(data) {
    const tBody = document.getElementById('transports');
    tBody.innerHTML = '';


    const button = document.createElement('button');

    data.forEach(transport => {
        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${transport.id})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteTransport(${transport.id})`);

        let tr = tBody.insertRow();


        let td1 = tr.insertCell(0);
        let textNode = document.createTextNode(transport.name);
        td1.appendChild(textNode);

        let td3 = tr.insertCell(1);
        td3.appendChild(editButton);

        let td4 = tr.insertCell(2);
        td4.appendChild(deleteButton);
    });

    transports = data;
}

function getTransports() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayTransports(data));
        //.catch(error => console.error('Unable to get transports.', error));
}

function addTransport() {
    const addNameTextbox = document.getElementById('add-name');

    const transport = {
        name: addNameTextbox.value.trim(),
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(transport)
    })
        .then(response => response.json())
        .then(() => {
            getTransports();
            addNameTextbox.value = '';
        })
        .catch(error => console.error('Unable to add transport.', error));
}

function deleteTransport(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getTransports())
        .catch(error => console.error('Unable to delete transport.', error));
}

function displayEditForm(id) {
    const transport = transports.find(tr => tr.id === id);

    document.getElementById('edit-id').value = transport.id;
    document.getElementById('edit-name').value = transport.name;
    document.getElementById('editForm').style.display = 'block';
}

function updateTransport() {
    const transportId = document.getElementById('edit-id').value;
    const transport = {
        id: parseInt(transportId, 10),
        name: document.getElementById('edit-name').value.trim()
    };
    fetch(`${uri}/${transportId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(transport)
    })
        .then(() => getTransports())
        //.catch(error => console.error('Unable to update transport.', error));

    closeInput();

    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}


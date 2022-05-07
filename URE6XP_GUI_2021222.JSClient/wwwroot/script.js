
let InstructorList = [];
let connection = null;
let NeptunIdToUPdate = null;
setupSignalR();
GetInstructorData();


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:60173/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("InstructorCreated", (user, message) => {
        GetInstructorData();
        console.log(message);
    });

    connection.on("InstructorDeleted", (user, message) => {
        GetInstructorData();
        console.log(message);
    });
    connection.on("InstructorUpdated", (user, message) => {
        GetInstructorData();
        console.log(message);
    });

    connection.onclose(async () => {
        await start();
    });
    start();


}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};



async function GetInstructorData(){
    await fetch('http://localhost:60173/instructor')
        .then(x => x.json())
        .then(y => {
            InstructorList = y;
            displayInstructor();
        });
}





function displayInstructor() {

    let index = 0;
    document.getElementById('Instructors').innerHTML = '';
    InstructorList.forEach(t => {

        document.getElementById('Instructors').innerHTML +=
            "<tr><td>" + t.neptunId + "</td><td>"
            + t.name + "</td><td>"
        + `<button type="button" onclick="InstructorDelete(${index})">Delete</button>`
        + `<button type="button" onclick="ShowInstructorUpdate(${index})">Update</button>`
            + "</td></tr>";

        index += 1;
    }
    );
}

function ShowInstructorUpdate(id) {
    document.getElementById('UpdateInstructorDiv').style.display = 'flex';
    document.getElementById('InstructorNameTuUpdate').value = InstructorList[id].name;
    NeptunIdToUPdate = InstructorList[id].neptunId;
    
}

function InstructorDelete(id) {
    fetch('http://localhost:60173/instructor/' + InstructorList[id].neptunId, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    }).then(response => response)
        .then(data => {
            console.log('Success:', data);
            GetInstructorData()
        })
        .catch((error) => { console.error('Error:', error); });
}

function InstructorCreate() {
    let name = document.getElementById('InstructorName').value;
    let neptunId = document.getElementById('InstructorNeptunId').value;
    fetch('http://localhost:60173/instructor', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { name: name, neptunid: neptunId })
        })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            GetInstructorData()
        })
        .catch((error) => { console.error('Error:', error); });  
}
function InstructorUpdate() {
    document.getElementById('UpdateInstructorDiv').style.display = 'none';
    let name = document.getElementById('InstructorNameTuUpdate').value;
    fetch('http://localhost:60173/instructor', {
        method: 'Put',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { name: name, neptunid: NeptunIdToUPdate })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            GetInstructorData()
        })
        .catch((error) => { console.error('Error:', error); });
}
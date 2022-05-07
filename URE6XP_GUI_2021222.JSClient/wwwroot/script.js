
let InstructorList = [];
let PresentationList = [];
let LectureHallList = [];

let connection = null;

let NeptunIdToUPdate = null;
let PersentationToUPdate = null;
let RoomNumberToUPdate = null;

setupSignalR();

GetInstructorData();
GetPresentationData();
GetLectureHallData();


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



    connection.on("LectureHallCreate", (user, message) => {
        GetLectureHallData();
        console.log(message);
    });
    connection.on("LectureHallUpdated", (user, message) => {
        GetLectureHallData();
        console.log(message);
    });
    connection.on("LectureHallDelete", (user, message) => {
        GetLectureHallData();
        console.log(message);
    });


    connection.on("InstructorUpdated", (user, message) => {
        GetInstructorData();
        console.log(message);
    });
    connection.on("InstructorUpdated", (user, message) => {
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
            console.log(InstructorList);
            displayInstructor();
        });
}
async function GetPresentationData() {
    await fetch('http://localhost:60173/presentation')
        .then(x => x.json())
        .then(y => {
            PresentationList = y;
            console.log(PresentationList);
            displayPresentation();
        });
}
async function GetLectureHallData() {
    await fetch('http://localhost:60173/lecturehall')
        .then(x => x.json())
        .then(y => {
            LectureHallList = y;
            console.log(LectureHallList);
            displayLectureHall();
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

function displayPresentation() {

    let index = 0;
    document.getElementById('Presentations').innerHTML = '';

    PresentationList.forEach(t => {

        document.getElementById('Presentations').innerHTML +=
            "<tr><td>" + t.presentationName + "</td><td>"
        + t.instrctoreNeptunId + "</td><td>"
        + t.roomNumber + "</td><td>"
        + `<button type="button" onclick="PresentationDelete(${index})">Delete</button>`
        + `<button type="button" onclick="ShowPresentationUpdate(${index})">Update</button>`
        + "</td></tr>";

        index += 1;
    }
    );
}

function displayLectureHall() {

    let index = 0;
    document.getElementById('LectureHalls').innerHTML = '';
    LectureHallList.forEach(t => {

        document.getElementById('LectureHalls').innerHTML +=
            "<tr><td>" + t.roomNumber + "</td><td>"
            + t.capacity + "</td><td>"
            + `<button type="button" onclick="LectureHallDelete(${index})">Delete</button>`
            + `<button type="button" onclick="ShowLectureHallUpdate(${index})">Update</button>`
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

function ShowPresentationUpdate(id) {
    document.getElementById('UpdatePresentationDiv').style.display = 'flex';
    document.getElementById('PresentationInstructorNeptunIdToChange').value = PresentationList[id].instrctoreNeptunId;
    document.getElementById('PresentationRoomNumberToChange').value = PresentationList[id].roomNumber;
    PersentationToUPdate = PresentationList[id].presentationName;

}

function ShowLectureHallUpdate(id) {
    document.getElementById('UpdateLectureHallDiv').style.display = 'flex';
    document.getElementById('LectureHallCapacityToUpdate').value = LectureHallList[id].capacity;
    RoomNumberToUPdate = LectureHallList[id].roomNumber;

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

function PresentationDelete(id) {
    fetch('http://localhost:60173/presentation/' + PresentationList[id].presentationName, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    }).then(response => response)
        .then(data => {
            console.log('Success:', data);
            GetPresentationData()
        })
        .catch((error) => { console.error('Error:', error); });
}

function LectureHallDelete(id) {
    fetch('http://localhost:60173/lecturehall/' + LectureHallList[id].roomNumber, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    }).then(response => response)
        .then(data => {
            console.log('Success:', data);
            GetLectureHallData()
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

function PresentationCreate() {
    let presentationName = document.getElementById('PresentationName').value;
    let InstructorNeptunId = document.getElementById('PresentationInstructorNeptunId').value;
    let RoomNumber = document.getElementById('PresentationRoomNumber').value;
    fetch('http://localhost:60173/presentation', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { instrctoreNeptunId: InstructorNeptunId, presentationName: presentationName, roomNumber: RoomNumber })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            GetPresentationData()
        })
        .catch((error) => { console.error('Error:', error); });
}

function LectureHallCreate() {
    let roomNumber = document.getElementById('LectureHallRoomNumber').value;
    let capacity = document.getElementById('LectureHallCapacity').value;
    fetch('http://localhost:60173/lecturehall', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { capacity: capacity, roomNumber: roomNumber })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            GetLectureHallData()
        })
        .catch((error) => { console.error('Error:', error); });
}

function InstructorUpdate() {
    document.getElementById('UpdateInstructorDiv').style.display = 'none';
    let name = document.getElementById('InstructorNameTuUpdate').value;
    fetch('http://localhost:60173/instructor', {
        method: 'PUT',
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

function PresentationUpdate() {
    document.getElementById('UpdatePresentationDiv').style.display = 'none';
    let neptunId = document.getElementById('PresentationInstructorNeptunIdToChange').value;
    let RoomNumber = document.getElementById('PresentationRoomNumberToChange').value;
    fetch('http://localhost:60173/presentation', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { instrctoreNeptunId: neptunId, presentationName: PersentationToUPdate, roomNumber: RoomNumber})
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            GetPresentationData()
        })
        .catch((error) => { console.error('Error:', error); });
}

function LectureHallUpdate() {
    document.getElementById('UpdateLectureHallDiv').style.display = 'none';
    let capacity = document.getElementById('LectureHallCapacityToUpdate').value;
    fetch('http://localhost:60173/lecturehall', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { capacity: capacity, roomNumber: RoomNumberToUPdate })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            GetLectureHallData()
        })
        .catch((error) => { console.error('Error:', error); });
}
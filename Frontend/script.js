let currentBalance = 0;
let date = document.querySelector("#date-input").value;

let array = [];

// async = we must wait for the backend to respond, before we can continue with the code
async function addItem() { 
    let date = document.querySelector("#date-input").value;
    let name = document.querySelector("#name-input").value;
    let amount = document.querySelector("#amount-input").value;
    let type = document.querySelector("#type-input").value;
        
    if (date === "" || name === "" || amount === "") {
    alert("All fields are required.");
    return;
    }

    if (amount < 0) {
    alert("Amount must be above 0.");
    return;
    }

    array = [];
    for (let i = 0; i < date.length; i++) {
        array.push(date[i]);
    }

    console.log(array);

    if (array[0] == 2 && array[1] == 0 && array[2] == 2){
        if (array[3] < 5 || array[3] > 6){
            alert("Not accepted date");
            return;
        }
    }
    else{
        alert("Not accepted date");
        return;
    }

    let amountNumber = parseInt(amount);

    if (type === "expense") {
        currentBalance -= amountNumber;
    } else{
        currentBalance += amountNumber;
    }

    let tableBody = document.querySelector("#list-body");

    const expenseColor = '#ff8a65';
    const incomeColor = '#26c6da';

    let newRow = `
        <tr>
            <td>${date}</td>
            <td>${name}</td>
                <td style="font-weight:bold; color: ${type === 'expense' ? expenseColor : incomeColor}">
                    ${amountNumber} Ft
                </td>
                <td>${type === 'expense' ? 'Expense' : 'Income'}</td>
        </tr>
    `;

    tableBody.innerHTML += newRow;
    document.querySelector("#total-balance").innerText = currentBalance;

    //send data to backend
    const transactionData = {
        date: date,
        name: name,
        amount: parseInt(amount),
        type: type == "expense" ? 0 : 1
    };

    try {
        // Replace with your actual API endpoint, await = wait for the response before moving on
        const response = await fetch('http://localhost:5085/api/budget', {
            // Not just bringing, but also sending data, so POST method
            method: 'POST',
            headers: {
                // Whats being sent is in JSON format, so we need to specify that in the header
                'Content-Type': 'application/json'
            },
            // We need to convert the JavaScript object into a JSON string before sending it
            body: JSON.stringify(transactionData)
        });

        if (!response.ok) {
            throw new Error('Network response was not ok');
        } else {
            console.log('Data sent successfully');
        }
    } catch (error) {
        console.error('There was a problem with the fetch operation:', error);
    }


    // refresh
    document.getElementById("name-input").value = "";
    document.getElementById("amount-input").value = "";
};
    
    window.onload = async function() {
    const response = await fetch('http://localhost:5085/api/Budget');
    const adatok = await response.json();
    console.log("A szerveren tárolt tételek:", adatok);

    let tableBody = document.querySelector("#list-body");

    adatok.forEach(item => {
        let row = `
            <tr>
                <td>${item.date.split('T')[0]}</td>
                <td>${item.name}</td>
                <td>${item.amount} Ft</td>
                <td>${item.type === 0 ? 'Expense' : 'Income'}</td>
            </tr>
        `;
        tableBody.innerHTML += row;
    });
}

let currentBalance = 0;
let date = document.querySelector("#date-input").value;

let array = [];

function addItem() { 
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
            alert("Not accepted datae");
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

    // refresh
    document.getElementById("name-input").value = "";
    document.getElementById("amount-input").value = "";

}

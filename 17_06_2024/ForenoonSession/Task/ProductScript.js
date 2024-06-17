
var GetProduct = () => {
    fetch("https://dummyjson.com/products",{
        method: 'GET',
    })
    .then(async (response) => {
        const data = await response.json();
        console.log(data);
        var divProducts = document.getElementById("products");

        divProducts.innerHTML = "";

        var tableHeader = document.createElement("tr");

        var nameHeader = document.createElement("th");
        nameHeader.textContent = "Name";
        var priceHeader = document.createElement("th");
        priceHeader.textContent = "Price";
        tableHeader.appendChild(nameHeader);
        tableHeader.appendChild(priceHeader);
        divProducts.appendChild(tableHeader);


        data.products.forEach(element => {
            var tableRow = document.createElement("tr");

            var nameCell = document.createElement("td");
            nameCell.textContent = element.title;
            var priceCell = document.createElement("td");
            if(element.price <20){
                nameCell.style.color = "red";
                priceCell.style.color = "red";
            }
            priceCell.textContent = element.price;
            tableRow.appendChild(nameCell);
            tableRow.appendChild(priceCell);
            divProducts.appendChild(tableRow);
        });
    })
    .catch((error) => {
        console.error('Error:', error);
    });
}
function FetchData() {
    GetProduct();
}
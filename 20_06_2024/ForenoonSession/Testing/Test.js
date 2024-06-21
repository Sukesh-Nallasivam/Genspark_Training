function test() {
        var h2select = document.querySelector('h2');
        
        if (h2select) {
            var h2innerHTML = h2select.innerHTML.trim();
            
            if (h2innerHTML === "Testing Frontend") {
                console.log("Test Passed");
                h2select.style.color = "green";
            } else {
                console.log("Test Failed");
                h2select.style.color = "red";
            }
        } else {
            console.log("No <h2> element found");
        }
}
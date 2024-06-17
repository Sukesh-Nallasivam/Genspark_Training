let ProfessionSelect = document.getElementById("profession");
let ProfessionArray = ["Select", "Public", "Private", "Self Employed", "Student", "Unemployed", "Other"];


ProfessionSelect.addEventListener("focus",()=>{
    let ProfessionOptions = ProfessionArray.map(profession=>`<option value="${profession.toLowerCase()}">${profession}</option>`).join("\n");
    ProfessionSelect.innerHTML = ProfessionOptions;
})


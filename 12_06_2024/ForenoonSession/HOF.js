let OddSum=0
let EvenSum=0
const SumOfOddNumbers = function(OddNumbers){
    OddSum+=OddNumbers
    console.log("Sum of Odd Numbers is: ",OddSum)
    return OddSum
}

const SumOfEvenNumbers = function(EvenNumbers){
    EvenSum+=EvenNumbers
    console.log("Sum of Even Numbers is: ",EvenSum)
    return EvenSum
}


let StartingNumber = 0
let EndingNumber = 0

function SumOfAllNumbers(StartingNumber,EndingNumber,SumOfOddNumbers,SumOfEvenNumbers)
{
    let sum1=0
    let sum2=0
    for(let i=StartingNumber;i<=EndingNumber;i++)
    {
        if(i%2==0)
        {
            sum1=SumOfEvenNumbers(i)
        }
        else
        {
            sum2=SumOfOddNumbers(i)
        }
        
    }
    return(sum1+sum2)
}

let sum=SumOfAllNumbers(StartingNumber,EndingNumber,SumOfOddNumbers,SumOfEvenNumbers)
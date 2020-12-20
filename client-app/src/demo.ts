export interface ICar {
    color: string,
    model: string,
    topSpeed?: number
}

const myCar: ICar = {
    color: "yellow",
    model: "pride"
}

const myOtherCar: ICar = {
    color: "blue",
    model: "peugeot",
    topSpeed: 210
}

myCar.color = "red";

const sum = (x: number, y: number) => {
    return x + y
}

myCar.topSpeed = sum(10, 25);
myOtherCar.topSpeed = sum(21, 150);

export const cars = [myCar, myOtherCar];
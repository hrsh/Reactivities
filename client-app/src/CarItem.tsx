import React from 'react'
import { ICar } from './demo'

interface IProps {
    car: ICar
}

const CarItem: React.FC<IProps> = ({ car }) => {
    return (
        <div>
            <h1>{car.model}, {car.color} with top speed of {car.topSpeed}</h1>
        </div>
    )
}
export default CarItem
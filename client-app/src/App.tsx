import React from 'react';
import './App.css';
import CarItem from './CarItem';
import { cars } from './demo';


const App: React.FC = () => {
  return (
    <div className="App">
      <div>
        {cars.map((car) => (
          <CarItem car={car} />
        ))}
      </div>
    </div>
  );
}

export default App;

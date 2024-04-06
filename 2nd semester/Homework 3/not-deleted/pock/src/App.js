import './App.css';
import MainPage from './pages/MainPage/components/PokemonCards.js';
import Header from './components/header';
import {useState} from 'react'

function App() {

  const [inputData, setInputData] = useState('');

  const handleInputChange = (value) => {
    setInputData(value)
  }

  console.log(inputData)

  return (
    <div className="App">
      <Header onInputChange={handleInputChange}/>
      <MainPage filteredData={inputData}/>
    </div>
  );
}

export default App;
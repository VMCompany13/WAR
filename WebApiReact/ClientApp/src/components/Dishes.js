import React, { Component } from 'react';
import { useState } from 'react';
//import TestFunction from './TestComponent'

//import getCurrentSelectedUser from './TestComponent'

import Select from 'react-select';

const options = [
  { value: 'Vlad', label: 'VladOS' },
  { value: 'IULIIA', label: 'July' },
];

let selectedValue;

export class Dishes extends Component {
  static displayName = Dishes.name;


  constructor(props) {
    super(props);
    this.state = { dishes: [], loading: true};
    
  }

  componentDidMount() {
    this.populateWeatherData();
  }

  async sendGetByUser() {
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' }
    };
    const response = await fetch('users?name='+ selectedValue, requestOptions);
    const data = await response.json();
    this.setState({ dishes: data, loading: false });
}
  

  static renderDishesTable(dishes) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Name</th>
            <th>Ccal</th>
          </tr>
        </thead>
        <tbody>
          {dishes.map(dish =>
            <tr key={dish.dishId}>
              <td>{dish.name}</td>
              <td>{dish.ccal}</td>
            </tr>
  )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : Dishes.renderDishesTable(this.state.dishes);

    return (
      <div>
        <h1 id="tabelLabel" >Weather forecast</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      
      <select name="cars" id="cars">
      <optgroup label="Swedish Cars">
        <option value="volvo">Volvo</option>
        <option value="saab">Saab</option>
      </optgroup>
      <optgroup label="German Cars">
        <option value="mercedes">Mercedes</option>
        <option value="audi">Audi</option>
      </optgroup>
    </select>
    <button onClick={() => this.sendGetByUser()}>Submit</button>
    <TestFunction></TestFunction>
    </div>
    );
  }

  async populateWeatherData() {
    const response = await fetch('dishes');
    const data = await response.json();
    this.setState({ dishes: data, loading: false });
  }
}

function TestFunction() {
    const [selectedOption, setSelectedOption] = useState(null);
  
    selectedValue = selectedOption?.value;
    return (
      <div className="App">
        <Select
          defaultValue={selectedOption}
          onChange={setSelectedOption}
          options={options}
        />
      </div>
    );
  }
  export default TestFunction

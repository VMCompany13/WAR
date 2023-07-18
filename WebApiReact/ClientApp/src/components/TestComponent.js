import React, { useState } from 'react';
import Select from 'react-select';

const options = [
  { value: 'chocolate', label: 'Chocolate' },
  { value: 'strawberry', label: 'Strawberry' },
  { value: 'vanilla', label: 'Vanilla' },
];

let selectedValue;

export function getCurrentSelectedUser(){
  return selectedValue?.value;
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
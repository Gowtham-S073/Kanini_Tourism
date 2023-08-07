import React, { useState } from 'react';

function TravelAgent() {
  const [inputCount, setInputCount] = useState(1);
  const [inputData, setInputData] = useState([{ label: '', value: '' }]);

  const handleInputChange = (index, event) => {
    const { name, value } = event.target;
    const updatedInputData = [...inputData];
    updatedInputData[index] = { ...inputData[index], [name]: value };
    setInputData(updatedInputData);
  };

  const handleAddInput = () => {
    const newInputData = Array.from({ length: inputCount }, () => ({
      label: '',
      value: '',
    }));
    setInputData([...inputData, ...newInputData]);
  };

  const handleRemoveInput = (index) => {
    setInputData(inputData.filter((item, i) => i !== index));
  };

  return (
    <div>
      <input
        type="number"
        value={inputCount}
        onChange={(event) => setInputCount(parseInt(event.target.value))}
      />
      <button type="button" onClick={handleAddInput}>
        Add Input
      </button>
      {inputData.map((input, index) => (
        <div key={index}>
          <label>
            Label {index + 1}:
            <input
              type="text"
              name="label"
              value={input.label}
              onChange={(event) => handleInputChange(index, event)}
              required
            />
          </label>
          <label>
            Input {index + 1}:
            <input
              type="text"
              name="value"
              value={input.value}
              onChange={(event) => handleInputChange(index, event)}
              required
            />
          </label>
          {index > 0 && (
            <button type="button" onClick={() => handleRemoveInput(index)}>
              Remove
            </button>
          )}
        </div>
      ))}
    </div>
  );
}

export default TravelAgent;

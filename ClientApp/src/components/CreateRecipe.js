import React, { useState } from 'react';
import axios from 'axios';

function CreateRecipeForm() {
  const [name, setName] = useState('');
  const [description, setDescription] = useState('');
  const [malt, setMalt] = useState('');
  const [hop, setHop] = useState('');
  const [maltAmount, setMaltAmount] = useState('');
  const [hopAmount, setHopAmount] = useState('');

  const handleSubmit = event => {
    event.preventDefault();

    const recipe = {
      name,
      description,
      malt,
      hop,
      maltAmount,
      hopAmount
    };

    axios.post('/api/recipe', recipe)
      .then(response => {
        console.log(response.data);
      })
      .catch(error => {
        console.error(error);
      });

    setName('');
    setDescription('');
    setMalt('');
    setHop('');
    setMaltAmount('');
    setHopAmount('');
  };

  return (
    <form onSubmit={handleSubmit}>
      <label>Name:</label>
      <input type="text" value={name} onChange={e => setName(e.target.value)} />
      <label>Description:</label>
      <input type="text" value={description} onChange={e => setDescription(e.target.value)} />
      <label>Malt:</label>
      <input type="text" value={malt} onChange={e => setMalt(e.target.value)} />
      <label>Hops:</label>
      <input type="text" value={hop} onChange={e => setHop(e.target.value)} />
      <label>Malt Amount:</label>
      <input type="text" value={maltAmount} onChange={e => setMaltAmount(e.target.value)} />
      <label>Hop Amount:</label>
      <input type="text" value={hopAmount} onChange={e => setHopAmount(e.target.value)} />
      <button type="submit">Create Recipe</button>
    </form>
  );
}

export default CreateRecipeForm;

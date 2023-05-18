import './App.css';
import RecipeForm from './RecipeForm';
import SearchRecipes from './SearchRecipes';

function App() {
  return (
    <div className="App">
      <div className="left">
        <h1>Beer Recipe Form</h1>
        <RecipeForm />
      </div>
      <div className="right">
        <SearchRecipes />
      </div>
    </div>
  );
}

export default App;



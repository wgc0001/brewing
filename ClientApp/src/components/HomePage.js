import React, { Component } from "react";
import { Link } from 'react-router-dom';

class HomePage extends Component {
    render(){
        return (
            <div>
            <header>
              <h1>Welcome to My Homebrewing Recipe App!</h1>
            </header>
            <main>
              <p>Click the button below to add a new recipe:</p>
              <Link to="/CreateRecipe.js"><button>Add New Recipe</button></Link>
            </main>
          </div>
        );
    }
}

export default HomePage;
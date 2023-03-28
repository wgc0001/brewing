import React from "react";
import {Link} from "react-router-bootstrap";

function HomePage(){
    return (
        <div>
            <header>
                <h1>Welcome to Will's Homebrewing Recipe App!</h1>
            </header>
            <main>
                <p>Click the button below to add a new recipe</p>
                <link to ="AddRecipe"><button>Add Recipe</button></link>
                <p>Click the button below to search for recipes</p>
                <link to ='SearchRecipe'><button>Search Recipe</button></link>
            </main>
        </div>
    )
}

export default HomePage;
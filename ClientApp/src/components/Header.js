import React from "react";

export const Header =() => {

    const headerStyle ={
        width: '100%',
        padding: '5%',
        backgroundColor: "green",
        color: "black",
        textAlign: 'center'
    }

    return (
        <header style={headerStyle}>
        <h1>Book Management App</h1>
        <hr />
        <div className="links">
          <NavLink to="/" className="link" activeClassName="active" exact>
            
          </NavLink>
          <NavLink to="/add" className="link" activeClassName="active">
            Add Recipe
          </NavLink>
        </div>
      </header>
    );
};

export default Header;
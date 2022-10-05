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
        <div style={headerStyle}>
            <h1>Brewing App</h1>
        </div>
    )

}
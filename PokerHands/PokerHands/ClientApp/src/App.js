import React, { Component } from 'react';
import Winner from './components/Winner'
import PlayerInfo from './components/Players';

class App extends Component {
    state = {
        winners: [],
    isLoading: false,
    error: null,
};

    
    componentDidMount() {
        fetch('http://localhost:3000/Card',
            {
                headers: {
                    'Access-Control-Allow-Origin': '*',                                        
                    'Access-Control-Allow-Origin': 'http://localhost:3000'                    
                }

            })
            .then(res => res.json())
            .then((data) => {
                this.setState({ winners: data })
            })
            .catch(console.log)
    }
    render() {
        return (
            
            <div className="App">
                <h1>Poker Hands</h1>              
                <PlayerInfo/>

                
            </div>

            
        )
    }
}

export default App;
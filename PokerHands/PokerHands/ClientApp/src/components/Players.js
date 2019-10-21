import React from 'react';
import Winner from './Winner'
class PlayerInfo extends React.Component {
    
    constructor(props) {
        super(props);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.input = React.createRef();

        this.state = {
            player1: '',
            player2: '',
            showWinner: false,
            winners: [{ "date": "2019-10-20", "winner": " WINS!", "player1CardList": "  ", "player2CardList": " ", "player1Hand": "Nothing", "player2Hand": "OnePair" }]
        }
        this.player1Update = this.player1Update.bind(this);
        this.player2Update = this.player2Update.bind(this);


    }

    handleSubmit(event) {
        console.log('Player 1 is: ' + this.state.player1)
        console.log('Player 2 is: ' + this.state.player2)

        fetch('http://localhost:3000/Card?p1=' + this.state.player1 + '&p2=' + this.state.player2,
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
        showWinner: true;
    }


    player1Update(event) {
        this.setState({ player1: event.target.value })
    }

    player2Update(event) {
        this.setState({ player2: event.target.value })
    }

    render() {
        return (
            <form onSubmit={this.handleSubmit}>
                <input
                    name='player1'
                    type='text' onChange={this.player1Update}
                    placeholder='enter Player 1 Name' />
                <input
                    name='player2'
                    type='text' onChange={this.player2Update}
                    placeholder='enter Player 2 Name' />

                <input type="button" value="Deal" id="addpix" onClick={this.handleSubmit} />
                <Winner winners={this.state.winners} /> 
                
            </form>
        );
    }

}

export default PlayerInfo
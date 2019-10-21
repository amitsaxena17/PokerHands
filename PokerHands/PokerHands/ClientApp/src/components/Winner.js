import React from 'react';




const Winner = ({ winners }) => {
    return (
        <div>
            
            {winners.map((winner) => (
                <div class="card">
                    <div class="card-body">                        
                        <h6 class="card-title">WINNER - {winner.winner}</h6>                        

                        <br/>
                        <br/>
                        <h6 class="card-subtitle mb-2 text-muted">Player 1 - Card List - {winner.player1CardList}</h6>                        
                        <h6 class="card-subtitle mb-2 text-muted">Player 2 - Card List {winner.player2CardList}</h6>               
                        <br/>
                        <h6 class="card-subtitle mb-2 text-muted">Player 1 Hand - {winner.player1Hand}</h6>                                                
                        <h6 class="card-subtitle mb-2 text-muted">Player 2 Hand  - {winner.player2Hand}</h6>                        
                    </div>
                </div>
            ))}
        </div>
    )
};

export default Winner
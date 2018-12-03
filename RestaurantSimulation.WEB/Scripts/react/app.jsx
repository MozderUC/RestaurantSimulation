
const ClientService = [
    { TableNumber: 1 },
    { TableNumber: 2 },
    { TableNumber: 3 }
    
];

const RestarauntMenu = [
    { Dish: 'Galaxy', Cost: 12 },
    { Dish: 'Vinegrette', Cost: 12 },
    { Dish: 'Goroshek', Cost: 12 }
];


class MakeOrder extends React.Component {

    constructor(props) {
        super(props);
        this.state = { clientOrders: []};

        // This binding is necessary to make `this` work in the callback
        this.handleClick = this.handleClick.bind(this);
        this.handleClientOrderChange = this.handleClientOrderChange.bind(this);
    }

    handleClientOrderChange() {
        this.props.onClientOrderChange(this.state.clientOrders, this.props.tableNumber);
    }

    handleClick(e) {
        console.log('The link was clicked.', e.target.getAttribute('data-item'));
        const clientOrders = this.state.clientOrders;

        const clientOrder = { Id: clientOrders.length + 1, Dish: e.target.getAttribute('data-item')};
    
        const newClientOrders = clientOrders.concat([clientOrder]);
        console.log('new state: ', newClientOrders);
        this.setState({ clientOrders: newClientOrders });
    }

    render() {

        const rows = this.props.restarauntMenu.map((restarauntMenu) =>
            <tr onClick={this.handleClick}>
                <th data-item={restarauntMenu.Dish}>{restarauntMenu.Dish}</th>
                <th>{restarauntMenu.Cost}</th>
            </tr>
        )

        const orders = this.state.clientOrders.map((clientOrder) =>
            <li key={clientOrder.Id}>
                {clientOrder.Dish}
            </li>
        )

        return (
            <div className="card-body">
                <div className="modal-body row">
                    <div className="col-md-6">
                        Restaraunt Menu:
                        <table className="table" >
                            <thead>
                                <tr>
                                    <th>Dish</th>
                                    <th>Cost</th>
                                </tr>
                            </thead>
                            <tbody>{rows}</tbody>
                        </table>
                    </div>
                    <div className="col-md-6">
                        Client Order:
                        <ul>
                            {orders}
                            <button onClick={this.handleClientOrderChange}  className="btn btn-primary float-right">
                                {this.state.clientOrders.length > 0 ? 'Make Order' : 'Select Dish'}
                            </button>
                        </ul>
                    </div>
                </div>
            </div>
        );
    }
}

class CompleteOrder extends React.Component {

    constructor(props) {
        super(props);
        
        // This binding is necessary to make `this` work in the callback
        this.handleClick = this.handleClick.bind(this);
    }

    handleClick(e) {
        console.log('The link was clicked.', e.target.getAttribute('data-item'));
        
    }

    render() {

        const rows = this.props.restarauntMenu.map((restarauntMenu) =>
            <tr onClick={this.handleClick}>
                <th data-item={restarauntMenu.Dish}>{restarauntMenu.Dish}</th>
                <th>{restarauntMenu.Cost}</th>
            </tr>
        )

        const orders = this.state.clientOrders.map((clientOrder) =>
            <li key={clientOrder.Id}>
                {clientOrder.Dish}
            </li>
        )

        return (
            <div className="card-body">
                <div className="modal-body row">
                    <div className="col-md-6">
                        Restaraunt Menu:
                        <table className="table" >
                            <thead>
                                <tr>
                                    <th>Dish</th>
                                    <th>Cost</th>
                                </tr>
                            </thead>
                            <tbody>{rows}</tbody>
                        </table>
                    </div>
                    <div className="col-md-6">
                        Client Order:
                        <ul>
                            {orders}
                            <button className="btn btn-primary float-right">
                                {this.state.clientOrders.length > 0 ? 'Make Order' : 'Select Dish'}
                            </button>
                        </ul>
                    </div>
                </div>
            </div>
        );
    }
}


class ClientsServiceList extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            clientState: []
        };

        // This binding is necessary to make `this` work in the callback
        this.handleClientOrderChange = this.handleClientOrderChange.bind(this);
    }

    handleClientOrderChange(order,tableNumber) {
        this.props.onClientOrderChange(order,tableNumber);
    }

    render() {
        
        const clientsServices = this.props.clientService.map((clientService,index) =>

            <li key={clientService.TableNumber} className="article-list__li">
                <div className="card mx-auto">
                    <div className="card-header">
                        <h2>
                            Table - {clientService.TableNumber}
                        </h2>
                    </div>                   
                    {(() => {                      
                        switch (this.state.clientState[index]) {
                            case undefined: return <MakeOrder restarauntMenu={this.props.restarauntMenu} onClientOrderChange={this.handleClientOrderChange} tableNumber={clientService.TableNumber} />;
                            case 2: return "#00FF00";
                            case 3: return "#0000FF";                            
                        }
                    })()}
                    
                </div>
            </li>
        )
        return (
            <ul>
                {clientsServices}
            </ul>
        )             
    }
}

class AddClientsForm extends React.Component {
    render() {
        return (           
            <form >
                <div className="form-group">
                    <label> Add Clients:</label>
                    <input id="new-clientService" className="form-control" placeholder="Enter clients amount"/>
                </div>
                
                <button type="submit" className="btn btn-default"> Add </button>
            </form>            
        );
    }
}

class RestarauntSimulation extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            clientState: []
        };

        // This binding is necessary to make `this` work in the callback
        this.handleClientOrderChange = this.handleClientOrderChange.bind(this);
    }

    handleClientOrderChange(order,tableNumber) {
        console.log('handle event button',order,tableNumber);
    }

    render() {
        return (
            <div className="container">
                <div className="jumbotron">
                    <h1 className="display-3">
                        Restaraunt Simulation
                    </h1>
                </div>
                <ClientsServiceList clientService={this.props.clientService} restarauntMenu={this.props.restarauntMenu} onClientOrderChange={this.handleClientOrderChange}/>
                <AddClientsForm />
            </div>
        );
    }
}


ReactDOM.render(<RestarauntSimulation clientService={ClientService} restarauntMenu={RestarauntMenu} addClientsUrl="/restaurant/add" getClientsUrl="/restaurant/get" />, document.getElementById('content'));



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
        this.setState({ clientOrders: newClientOrders });
    }

    render() {

        const rows = this.props.restarauntMenu.map((restarauntMenu) =>
            <tr key={restarauntMenu.Dish} onClick={this.handleClick}>
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
                            {this.state.clientOrders.length > 0 ?
                                <button onClick={this.handleClientOrderChange} className="btn btn-primary float-right">
                                    {'Make Order'}
                                </button>
                                :""
                            }                           
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
        this.handleClientGetBill = this.handleClientGetBill.bind(this);
    }

    handleClientGetBill(e) {  
        this.props.onClientGetBill(this.props.tableNumber);
    }

    render() {

        const rows = this.props.clientService.map((clientService,index) =>
            <li key={index}>
                {clientService.Dish}
            </li>
        )
        
        return (
            <div className="card-body">
                Bon appetit!
                <ul>
                    {rows}
                    <button onClick={this.handleClientGetBill} className="btn btn-primary float-right">
                        {'Get Bill'}
                    </button>
                </ul>
            </div>
        );
    }
}

class BillOrder extends React.Component {

    constructor(props) {
        super(props);

        // This binding is necessary to make `this` work in the callback
        this.handlePaidOrder = this.handlePaidOrder.bind(this);
    }   

    handlePaidOrder() {
        this.props.onPaidOrder(this.props.clientService.TableNumber);
    }

    getTotalSum() {
        
        let sum=0;
        var i;
        for (i = 0; i < this.props.clientService.TableOrder.length; i++) {
            sum = sum + this.props.clientService.TableOrder[i].Cost;
        }
        console.log("came here", sum)
        return (
            <div>{sum}</div>
        )
    }

    render() {
        const rows = this.props.clientService.TableOrder.map((tableOrder) =>
            <tr key={tableOrder.Dish}>
                <th>{tableOrder.Dish}</th>
                <th>{tableOrder.Cost}</th>  
                
            </tr>
        );

        return (
            <div className="card-body">
                <h4>Order List:</h4>               
                <table className="table table-bordered">
                    <thead>
                        <tr>
                            <th>Dish</th>
                            <th>Cost</th>
                        </tr>
                    </thead>
                    <tbody>{rows}</tbody>
                    <tfoot>
                        <tr >
                            <th>Total Sum</th>
                            <th>{this.getTotalSum()} </th>
                        </tr>
                    </tfoot>
                </table>
                <button onClick={this.handlePaidOrder} className="btn btn-primary float-right">
                    {'Paid'}
                </button>
            </div>
        );
    }
}


class ClientsServiceList extends React.Component {
    constructor(props) {
        super(props);

        // This binding is necessary to make `this` work in the callback       
        this.handlePaidOrder = this.handlePaidOrder.bind(this);
        this.handleClientOrderChange = this.handleClientOrderChange.bind(this);
        this.handleClientGetBill = this.handleClientGetBill.bind(this);
    }

    handlePaidOrder(tableNumber) {
        this.props.onPaidOrder(tableNumber);
    }
    handleClientGetBill(tableNumber) {
        this.props.onClientGetBill(tableNumber);
    }
    handleClientOrderChange(order,tableNumber) {
        this.props.onClientOrderChange(order,tableNumber);
    }

    render() {
        
        const clientsServices = this.props.clientService.map((clientService) =>

            <li key={clientService.TableNumber} className="article-list__li">
                <div className="card mx-auto">
                    <div className="card-header">
                        <h2>
                            Table - {clientService.TableNumber}
                        </h2>
                    </div>                   
                    {(() => {
                        if (clientService.IsCreatedBill == true) {
                            return <BillOrder clientService={clientService} onPaidOrder={this.handlePaidOrder}/>;
                        }
                        if (clientService.TableOrder == undefined) {
                            return <MakeOrder restarauntMenu={this.props.restarauntMenu} onClientOrderChange={this.handleClientOrderChange} tableNumber={clientService.TableNumber} />;
                        }
                        if (clientService.TableOrder != undefined) {
                            return <CompleteOrder clientService={clientService.TableOrder} onClientGetBill={this.handleClientGetBill} tableNumber={clientService.TableNumber} />;
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
    constructor(props) {
        super(props);
        this.state = {
            ClientsAmount: '',
            errors: {}
        };
        this.handleClientsAmountChange = this.handleClientsAmountChange.bind(this);      
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleValidation() {
        let fields = this.state.ClientsAmount;
        let errors = {};
        let formIsValid = true;

        if (!fields) {
            formIsValid = false;
            errors["ClientsAmount"] = "Cannot be empty";
        }

        if (typeof fields !== "undefined") {
            if (!fields.match(/[1-9]/)) {
                formIsValid = false;
                errors["ClientsAmount"] = "Only digits 1..9";
            }    
        }

        this.setState({ errors: errors });
        return formIsValid;
    }

    handleClientsAmountChange(e) {
        console.log('Change client amount', e.target.value);
        this.setState({ ClientsAmount: e.target.value });
    }
    handleSubmit(e) {
        console.log('handle submit');

        e.preventDefault();

        if (this.handleValidation()) {
            
            this.props.onAddClientsSubmit(this.state.ClientsAmount)
            this.setState({ ClientsAmount: '' });           
        } else {
            alert("Form has errors.")
        }
        
    }

    render() {
        return (           
            <form onSubmit={this.handleSubmit} >
                <div className="form-group">
                    <label> Add Clients:</label>
                    <input id="new-clientService" className="form-control" placeholder="Enter clients amount" value={this.state.ClientsAmount} onChange={this.handleClientsAmountChange} />
                    <span >{this.state.errors["ClientsAmount"]}</span>
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
            clientState: [],
            restarauntMenu: []
        };

        // This binding is necessary to make `this` work in the callback
        this.handlePaidOrder = this.handlePaidOrder.bind(this);
        this.handleClientOrder = this.handleClientOrder.bind(this);
        this.handleGetBill = this.handleGetBill.bind(this);
        this.handleAddClientsSubmit = this.handleAddClientsSubmit.bind(this);
    }

    handlePaidOrder(tableNumber) {
        console.log('Handle paid', tableNumber);

        const data = new FormData();
        data.append('tableNumber', tableNumber);

        const xhr = new XMLHttpRequest();
        xhr.open('post', this.props.removeClientsUrl, true);
        xhr.onload = () => this.loadClienServicesFromServer();
        xhr.send(data);
    }
    handleGetBill(tableNumber) {
        console.log('Client want bill', tableNumber);

        const data = new FormData();
        data.append('tableNumber', tableNumber);

        const xhr = new XMLHttpRequest();
        xhr.open('post', this.props.getClientBillUrl, true);
        xhr.onload = () => this.loadClienServicesFromServer();
        xhr.send(data);
    }
    handleClientOrder(order, tableNumber) {
        let resultDish = order.map(a => a.Dish); 
        
        const data = new FormData();
        data.append('tableNumber', tableNumber);
        data.append('order', resultDish);
        console.log('handleClientOrder');

        const xhr = new XMLHttpRequest();
        xhr.open('POST', this.props.processClientOrderUrl, true);  
        xhr.onload = () => this.loadClienServicesFromServer();
        xhr.send(data);
    }
    handleAddClientsSubmit(clientAmount) {
        const data = new FormData();
        data.append('clientAmount', clientAmount);     
      
        const xhr = new XMLHttpRequest();
        xhr.open('post', this.props.addClientsUrl, true);
        xhr.onload = () => {
            const data = JSON.parse(xhr.responseText);
            if (data != "Success")
                alert(data)
            this.loadClienServicesFromServer();
        }
        xhr.send(data);
    }


    componentWillMount() {
        this.loadClienServicesFromServer();
        const xhr = new XMLHttpRequest();
        xhr.open('get', this.props.getMenuUrl, true);
        xhr.onload = () => {
            const data = JSON.parse(xhr.responseText);
            this.setState({ restarauntMenu: data });
        };
        xhr.send();
    }
    loadClienServicesFromServer() {
        console.log('loadClienServicesFromServer');
        const xhr = new XMLHttpRequest();
        xhr.open('get', this.props.getClientsUrl, true);
        xhr.onload = () => {
            console.log('responseText', xhr.responseText);
            const data = JSON.parse(xhr.responseText);

            this.setState({ clientState: data });
        };
        xhr.send();
    }
    
    render() {
        return (
            <div className="container">
                <div className="jumbotron">
                    <h1 className="display-3">
                        Restaraunt Simulation
                    </h1>
                </div>
                <ClientsServiceList clientService={this.state.clientState} restarauntMenu={this.state.restarauntMenu} onClientOrderChange={this.handleClientOrder} onClientGetBill={this.handleGetBill} onPaidOrder={this.handlePaidOrder}/>
                <AddClientsForm onAddClientsSubmit={this.handleAddClientsSubmit} />
            </div>
        );
    }
}


ReactDOM.render(<RestarauntSimulation addClientsUrl="/restaurant/addClients" getClientsUrl="/restaurant/getClients" getMenuUrl="/restaurant/getMenu" processClientOrderUrl="/restaurant/addClientOrder" getClientBillUrl="/restaurant/getClientBill" removeClientsUrl="/restaurant/removeClients" />, document.getElementById('content'));

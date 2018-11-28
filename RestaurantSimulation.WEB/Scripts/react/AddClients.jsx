class TodoApp extends React.Component {
    constructor(props) {
        super(props);
        this.state = { items: [], text: '' };
        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleClick(i) {
        
    }

    render() {
        return (
            <div>
                <h3>Clients Registration</h3>
                <TodoList items={this.state.items}
                    onClick = {i => this.handleClick(i)}/>
                <form onSubmit={this.handleSubmit}>
                    <label htmlFor="new-todo">
                        Add Clients number 
          </label>
                    <input
                        id="new-todo"
                        onChange={this.handleChange}
                        value={this.state.text}
                    />
                    <button>
                        Add #{this.state.items.length + 1}
                    </button>
                </form>
            </div>
        );
    }

    handleChange(e) {
        this.setState({ text: e.target.value });
    }

    loadVisitorsFromServer() {
        const xhr = new XMLHttpRequest();
        xhr.open('get', this.props.getClientsUrl, true);
        xhr.onload = () => {
            const data = JSON.parse(xhr.responseText);
            this.setState({ items: data });
        };
        xhr.send();
    }

    handleSubmit(e) {
        e.preventDefault();
        if (!this.state.text.length) {
            return;
        }
        
        const data = new FormData();
        data.append('VisitorsNumber', this.state.text);

        const xhr = new XMLHttpRequest();
        xhr.open('post', this.props.addClientsUrl, true);
        xhr.onload = () => this.loadVisitorsFromServer();
        xhr.send(data);

    }
}

class TodoList extends React.Component {
    render() {
        return (
            <ul>                 
                {this.props.items.map(item => (
                    <li key={item.id} onClick={this.props.onClick(item.TableNumber)}>Table number: {item.TableNumber}</li>
                ))}
            </ul>
        );
    }
}

ReactDOM.render(<TodoApp addClientsUrl="/restaurant/add" getClientsUrl="/restaurant/get" />, document.getElementById("root"));
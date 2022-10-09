import logo from './logo.svg';
import './App.css';
import '../node_modules/bootstrap/dist/css/bootstrap.min.css'

function App() {
  return (
    <div className="App">
      <header className="Pizza Poll">
      </header>
      <h1 className="card">Pizza Poll</h1>
      <body class="container bg-light">
        <div>
            <button class="btn btn-primary align-center" id="startSurvey">Start Survey</button>
            <button class="btn btn-success" id="surveyResults">See Survey Results</button> 
        </div>
      </body>
    </div>
  );
}

export default App;

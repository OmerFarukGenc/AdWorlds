const express = require('express');
const bodyParser = require("body-parser");
const { default: mongoose } = require('mongoose');

const app = express();

// file limits for express
app.use(express.json({ limit: '50mb' }));
app.use(express.urlencoded({ limit: '50mb' }));

const control = require('./routes/control');
const userProcessor = require("./middleswares/userProcessor");
const cors = require('cors')

// for local environment to ease proxy.
// app.use(express.static(path.join(__dirname,"public")));

app.use(cors({
    origin:"*",
    methods:['GET', 'POST']
}))

require('dotenv').config();
const dbconnect = async(DB_URL)=>{
    try {
        const conn = await mongoose.connect(DB_URL,{
            useUnifiedTopology:true,
            
            useUnifiedTopology:true
        })
        console.log(`db conncted. ${conn.connection.name }`)
    } catch (error) {
        console.log('db failed',error.message)
    }
};
app.use( express.json({limit:"100mb"}));

// routing control
app.use("/",userProcessor);

app.use( '/api', control );
const DB_URL = process.env.DB_URL;
dbconnect(DB_URL) 
const PORT = process.env.PORT || 3000; 



app.listen( PORT, () => {

    console.log(`Server listening ${PORT}`)
} )
const express = require('express');
const app = express();
const port = 3000;
const cardRoutes = require('./routes/cardRoutes');
const userRoutes = require('./routes/userRoutes');
const appointmentRoutes = require('./routes/appointmentRoutes');
const billRoutes = require('./routes/billRoutes');

const bodyParser = require('body-parser');
const db = require('./utils/db');

app.use(bodyParser.json());

app.use('/user',userRoutes);

app.use('/bill',billRoutes);
app.use('/appointment',appointmentRoutes);
app.use('/card',cardRoutes);

app.get('/',(req,res)=>{
    res.send("Hello World");
});

app.get('/welcome',(req,res)=>{
    res.send("Welcome Huzaifa");
});


app.listen(port,()=>{
    console.log(`Server is running on port: ${port}`)
});
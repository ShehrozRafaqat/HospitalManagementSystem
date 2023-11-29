const mongoose = require('mongoose');

const billSchema = new mongoose.Schema({
    
    appointment: String,
    amount: String

},{timestamps:true});

module.exports = mongoose.model('Bill',billSchema);
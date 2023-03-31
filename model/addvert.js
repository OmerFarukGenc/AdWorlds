const mongoose = require('mongoose');
const {Schema} = mongoose;
const addvertSchema = new Schema({
    addid:{type: String,require: true},
    addview:{type:String,require:true},
    addclik:{type:String,require:true},
    custid:{type: String,require: true},
    modeladd:{type: String,require: true}
})
const add = mongoose.model('add',addvertSchema);
module.exports = add;
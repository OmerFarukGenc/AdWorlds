const express = require('express');
const router = express.Router();
const {newAddvert, allAddvert, findAddvert,
       updateAddvertW, deleteAddvert,updateAddvertC } = require('../dbAccess/dbtrans')

router.post('/newAddvert/:Custid', newAddvert);

router.get('/allAddvert', allAddvert); 

router.get('/custAddvert/:id', findAddvert); 

router.put('/upaddvertW/:id', updateAddvertW); 

router.put('/upaddvertC/:id', updateAddvertC);

router.delete('/deladdvert/:id', deleteAddvert); 







module.exports = router; 
const express = require('express');
const router = express.Router();
const {newAddvert, allAddvert, findAddvert,

       updateAddvertW, deleteAddvert,updateAddvertC ,getRandomAddvert,downloadAdd, getRandomAdId, getAdFromId,getNewId
} = require('../dbAccess/dbtrans')


router.post('/newAddvert/:Custid', newAddvert);

router.get('/allAddvert', allAddvert); 

router.get('/custAddvert/:id', findAddvert); 

router.put('/upaddvertW/:id', updateAddvertW); 

router.put('/upaddvertC/:id', updateAddvertC);


router.get("/getNewId",getNewId);

router.delete('/deladdvert/:id', deleteAddvert); 

router.get("/getRandomAddvert",getRandomAddvert);

router.get("/downloadAdd",downloadAdd);

router.get("/getRandomAdId",getRandomAdId);

router.get("/getAdFromId/:id", getAdFromId);



router.get("/downloadTest",(req,res) => {

       res.download("assets/model.txt");
})



module.exports = router; 
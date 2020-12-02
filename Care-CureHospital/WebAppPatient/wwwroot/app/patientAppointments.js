Vue.component("patientAppointments", {
	data: function () {
		return {
			patientFeedbacks: [],
			filterAppointments: 'Svi pregledi'
		}
	},
	template: `
	<div>	
	<div class="boundaryForScrollAppointments">
	     <div class="logoAndName">
	         <div class="logo">        
	             <img src="images/hospital.png"/>
	         </div>
	         <div class="webName">
	             <h3></h3>
	         </div>  
	     </div>
	 
	     <div class="main">     
	         <ul class="menu-contents">
	            <li  class="active"><a href="#/medicalRecordReview">Moj nalog</a></li>
	         </ul>
	     </div>
 
	     <div class="dropdown">
	        <button class="dropbtn">
	        	<img id="menuIcon" src="images/menuIcon.png" />
	        	<img id="userIcon" src="images/user.png" />
	        </button>
		    <div class="dropdown-content">
		        <a href="#/patientRegistration">Registruj se</a>
	            <a >Prijavi se</a>
		    </div>
	    </div>
	 </div>
	 
	<div class="filterAppointments">
            <div class="form-title-appointments">
                <h1>Filtriraj preglede:</h1>
                <select v-model="filterAppointments">
                <option value="Svi pregledi" selected>Svi pregledi</option>
				<option value="Zakazani pregledi">Zakazani pregledi</option>
				<option value="Pregledi na kojima sam bio">Pregledi na kojima sam bio</option>
                </select>
		    </div>
     </div>

	 <div class="verticalLine"></div>
	
	 <div class="sideComponents">      
	     <ul class="ulForSideComponents">
			<div><li><a href="#/medicalRecordReview">Medicinski karton</a></li></div><br/>
		    <div><li class="active"><a href="#/patientAppointments">Moji pregledi</a></li></div><br/>
	     </ul>
	 </div> 		 
		 
	<div class="listOfAppointments">		 
	<div v-for="pf in patientFeedbacks" >	
		<div class="wrapper-appointments">
		    <div class="appointments-img">
		        <img src="./images/examination.png" height="150" width="150" style="margin-left: 20%; margin-top: 14%;">
		    </div>
		    <div class="appointments-info">
		        <div class="appointments-text">
					<h1>dr {{pf.patient}}</h1> 
					<h3>- Lekar opšte prakse</h3>
					<h3 style="margin-top:8px"><i>Ordinacija:</i> 201</h3>
					<h3 style="margin-top:8px"><i>Vreme:</i> 10:30 - 10:00</h3>
		            <p>{{pf.publishingDate}}</p>
					<div v-if="pf.isForPublishing === true && pf.isPublished === false" class="fillSurvey-btn">
                            <button type="button" @click="fillSurvey(pf)">Popuni anketu</button>
					</div>
					<div v-if="pf.isForPublishing === true && pf.isPublished === false" class="cancelAppointment-btn">
                            <button type="button" @click="cancelAppointment(pf)">Otkaži pregled</button>
					</div>
					<div v-else-if="pf.isForPublishing === true && pf.isPublished === true" class="appointmentsParagraph1">
                            <p>Popunili ste anketu</p>
					</div>
					<div v-else-if="pf.isForPublishing === false && pf.isPublished === false" class="appointmentsParagraph2">
                            <p>Otkazali ste pregled</p>
					</div>
		         </div>
			</div>
	     </div>		
	</div>
	</div>		     	  
	</div>
        
	`
	,
	methods: {
			
	},
	computed: {
		
	},
	mounted() {

		axios.get('api/patientFeedback').then(response => {
			this.patientFeedbacks = response.data;
		});

	}

});
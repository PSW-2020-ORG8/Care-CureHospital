Vue.component("publishedFeedbacks", {
	data: function (){
		return {
			patientFeedbacks : []
		}
	},
	template:`
	<div>
	
	 <div class="boundaryForScroll">
	     <div class="logoAndName">
	         <div class="logo">        
	             <img src="pictures/clinic.png"/>
	         </div>
	         <div class="webName">
	             <h3></h3>
	         </div>  
	     </div>
	 
	     <div class="main">     
	         <ul class="menu-contents">
	            <li  class="active"><a href="#/">Utisci pacijenata</a></li>
	         </ul>
	     </div>
 
	     <div class="dropdown">
	        <button class="dropbtn">
	        	<img id="menuIcon" src="pictures/menuIcon.png" />
	        	<img id="userIcon" src="pictures/user.png" />
	        </button>
		    <div class="dropdown-content">
		        <a href="">Registruj se</a>
	            <a href="">Prijavi se</a>
		    </div>
	    </div>
	 </div>
	 


	 <div class="verticalLine"></div>
	
	 <div class="sideComponents">      
	     <ul class="ulForSideComponents">
		    <div><li><a href="#/patientsFeedbacks">Svi utisci</a></li></div><br/>
		    <div><li class="active" ><a href="#/">Objavljeni utisci</a></li></div><br/>
			<div><li><a href="#/publishFeedback">Ostavite utisak</a></li></div><br/>
	     </ul>
	 </div>
	 
		 


	 <div class="titleForPublishedFeedbackPreview">
		 <h1>Utisci pacijenata</h1>
	 </div> 
		 

	 <div class="listOfFeedbacks">
		 
	 <div v-for="pf in patientFeedbacks" >	
	 	 
		<div class="wrapper">
		    <div class="feedback-img">
		        <img src="./pictures/comment.png" height="150" width="150" style="margin-left: 20%; margin-top: 14%;">
		    </div>
		    <div class="feedback-info">
		        <div class="feedback-text">
		            <h1 v-if="pf.isAnonymous === true">Anonimni pacijent</h1>
					<h1 v-else ></h1> <!-- OBRISAN: {{pf.patient.Name}} {{pf.patient.Surname}} -->
		            <h2></h2>
					<h3></h3>
					<div  style="overflow-y:scroll;height:100px;width:450px;">
						{{pf.text}}
				    </div>
		         </div>
			</div>
	     </div>
		
	 </div>
	<!--
	<template v-if="!patientFeedbacks || !patientFeedbacks.length"> 
		<div  class="emptyListOfFeedbacks">
			<h2 >Trenutno nema utisaka pacijenata!</h2>
		</div>
	</template >
	-->

	 </div>		     
		  
	</div>
        
	`	
	,
	methods: {
		
	
		},
	mounted(){

		axios.get('api/patientFeedback/getPublishedFeedbacks').then(response => {
			this.patientFeedbacks = response.data;
		});	
	
	}
	
});
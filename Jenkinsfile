node {
      
    stage("Checkout") {
		
      git url: "https://github.com/eltuna9/TheKey.git", branch: "master"
	  
    }
	
    stage ("Nuget Dep.") {

        bat 'c:\\Nuget\\nuget.exe restore TheKey.sln'

    }
    
    stage ("Build .NET") {

        bat "\"${tool 'MSBuild'}\" TheKey.sln /p:Configuration=Release /p:Platform=\"Any CPU\" /p:ProductVersion=1.0.0.${env.BUILD_NUMBER}"
        
    }

    stage ("Build Client") {

        bat 'cd TheKeyAPI\\ClientApp && npm install'
        
    }
}   
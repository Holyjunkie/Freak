import UnityEngine
//import System.IO

[CustomEditor(typeof(RageSvgIn))]
public class RageSvgInEditor (RageToolsEdit):
	
	private _svgIn as RageSvgIn
	private _existsDir as bool
	private _currentSvg as Object
	private _undoButton as Texture2D = Resources.Load('undo', Texture2D)
	
	protected override def OnDrawInspectorHeaderLine ():
		_svgIn = target if _svgIn==null	
		ifdef not UNITY_FLASH:
			EasyToggle "On Start", _svgIn.ImportOnStart, MaxWidth(75f)
			EasyToggle "URL", _svgIn.UseUrl, MaxWidth(45f)
		
			return if _svgIn.UseUrl
		
			if GUILayout.Button("Import", GUILayout.MaxHeight(18f)):
				Undo.RecordObject(target,"RageTools SVG Import")
				_svgIn.ImportFile()

			if GUILayout.Button(GUIContent(_undoButton, "Undo Import"), GUILayout.ExpandWidth(false), GUILayout.MinHeight(16)):
				_svgIn.UndoImport()

	ifdef not UNITY_FLASH:
		protected override def OnDrawInspectorGUI():
			_svgIn = target if _svgIn==null	
			EditorUtility.SetDirty (_svgIn)
		
			EasyRow:
				LookLikeControls(56f)
				if _svgIn.UseUrl:
					EasyTextField "URL", _svgIn.UrlPath								
				else:
					EasyObjectField "File", _svgIn.FileObject			

			if _svgIn.FileObject==null:
				EasyRow:
					Warning("SVG file field not set")
			else:
				if not _svgIn.FileObject == _currentSvg:
					_currentSvg = _svgIn.FileObject
					//_svgIn.FixPath()
		
			EasyRow:
				LookLikeControls(50f, 10f)
				EasyIntField "Density Min", _svgIn.MinVertexDensity
			
				LookLikeControls(30f, 10f)
				EasyIntField  "Max", _svgIn.MaxVertexDensity
				
			//_existsDir = Directory.Exists(_svgIn.AbsoluteDirectory)
			//_settings = true if not _existsDir
		
			EasySettings:
				//EasyRow:
				//	LookLikeControls(60f)
				//	EasyTextField "Directory ", _svgIn.Directory
				
				//if not Directory.Exists(_svgIn.AbsoluteDirectory):
				//	EasyRow:
				//		Warning("Invalid Directory: " + _svgIn.Directory)
														
				EasyRow:
					LookLikeControls(60f, 10f)
					EasyFloatField "AA Width ", _svgIn.AntialiasWidth, MaxWidth(127f)
					EasyFloatField "Z Offset ", _svgIn.ZsortOffset
				
				EasyRow:
					LookLikeControls(85f, 20f)
					EasyFloatField "Merge Radius ", _svgIn.MergeRadius, MaxWidth(127f)
					EasyToggle "Midline Controls ", _svgIn.MidlineControls
						
				EasyRow:
					LookLikeControls(60f, 15f)
					EasyToggle "Outline Behind Fill",_svgIn.OutlineBehindFill, MaxWidth(127f)
					EasyToggle "Create Holes",_svgIn.CreateHoles

				EasyRow:
					EasyToggle "Auto Layering",_svgIn.AutoLayering, MaxWidth(127f)
					EasyToggle "3D Mode", _svgIn.PerspectiveMode

				EasyRow:
					EasyToggle "Textures Alpha",_svgIn.TexturesAlpha, MaxWidth(127f)

				if _svgIn.AutoLayering:
					EasyRow:
						EasyToggle "Layer Group",_svgIn.AutoLayeringGroup, MaxWidth(127f)
						EasyToggle "Layer Materials",_svgIn.AutoLayeringMaterials

				if _svgIn.AutoLayering and _svgIn.AutoLayeringMaterials:
					EasyRow:
						Warning ("* Disregard error messages during import")
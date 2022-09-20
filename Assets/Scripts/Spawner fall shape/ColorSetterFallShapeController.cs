using UnityEngine;
using Zenject;

public class ColorSetterFallShapeController
{
    private Color _colorKillerShape;
    private Color _colorAddScoreShape;

    private RandomKindSetterController _randomKindSetterController;
    
    [Inject]
    public ColorSetterFallShapeController(SOSpawnSettings soSpawnSettingsArg, RandomKindSetterController randomKindSetterControllerArg)
    {
        _colorKillerShape = soSpawnSettingsArg._colorKillerShape;
        _colorAddScoreShape = soSpawnSettingsArg._colorAddScoreShape;
        _randomKindSetterController = randomKindSetterControllerArg;
        Subscribe();
    }

    private void Subscribe()
    {
        _randomKindSetterController.SetNewKindEvent += ChangeColor;
    }


    private void ChangeColor(FallShape fallShape)
    {
        KindFallShape kindFallShape = fallShape.GetKind();
        Color newColor = Color.black;
        
        
        if (kindFallShape == KindFallShape.killer)
        {
            newColor = _colorKillerShape;
        }

        if (kindFallShape == KindFallShape.addScore)
        {
            newColor = _colorAddScoreShape;
        }

        fallShape.gameObject.GetComponentInChildren<SpriteRenderer>().color = newColor;
    }
}
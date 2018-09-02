using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialAnimator : MonoBehaviour {

    [SerializeField]
    private List<MaterialAnimation> animations;

    private MeshRenderer meshRenderer;

    private MaterialAnimation currentAnimation;
    private int currentAnimationIndex = 0;
    private float currentFrameTime = 0.0f;

	void Start () {
        this.meshRenderer = this.GetComponent<MeshRenderer>();
	}
	
	void Update () {

        if (this.currentAnimation != null) {
            this.UpdateCurrentAnimation();
        }
    }

    public void SetCurrentAnimation(string name) {

        if (this.currentAnimation != null && name.Equals(this.currentAnimation.animationName)) {
            return;
        }

        this.currentAnimation = null;

        foreach (MaterialAnimation animation in this.animations) {

            if (animation.animationName.Equals(name)) {
                this.currentAnimation = animation;
                break;
            }
        }

        if (this.currentAnimation != null) {
            this.currentAnimationIndex = -1;
            this.SetNextAnimationFrame();
        }
    }

    private void UpdateCurrentAnimation() {
        this.currentFrameTime += Time.deltaTime;

        if (this.currentFrameTime >= this.currentAnimation.timeBetweenFrames)
        {
            this.SetNextAnimationFrame();
        }
    }

    private void SetNextAnimationFrame() {
        List<Sprite> spriteSheet = this.currentAnimation.spriteAnimationSheet;

        this.currentAnimationIndex = (this.currentAnimationIndex + 1) % spriteSheet.Count;

        Sprite sprite = spriteSheet[this.currentAnimationIndex];
        Texture texture = this.GetTextureOfSprite(sprite);
        this.meshRenderer.material.mainTexture = texture;

        this.currentFrameTime = 0.0f;
    }

    private Texture GetTextureOfSprite(Sprite sprite) {
        var croppedTexture = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height);
        var pixels = sprite.texture.GetPixels((int)sprite.textureRect.x,
                                                (int)sprite.textureRect.y,
                                                (int)sprite.textureRect.width,
                                                (int)sprite.textureRect.height);
        croppedTexture.SetPixels(pixels);
        croppedTexture.Apply();

        return croppedTexture;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialAnimator : MonoBehaviour {

    [SerializeField]
    private List<MaterialAnimation> animations;

    private MeshRenderer meshRenderer;

    private MaterialAnimation currentAnimation;
    private bool isOnForcePlay = false;
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

    public void SetCurrentAnimation(string name, bool flipHorizontal = false) {

        if (this.isOnForcePlay) {
            return;
        }

        this.SetFlipHorizontal(flipHorizontal);

        if (this.currentAnimation != null && name.Equals(this.currentAnimation.animationName)) {
            this.isOnForcePlay = this.currentAnimation.forcePlayOnce;
            return;
        }

        this.currentAnimation = null;

        foreach (MaterialAnimation matAnimation in this.animations) {

            if (matAnimation.animationName.Equals(name)) {
                this.currentAnimation = matAnimation;
                this.isOnForcePlay = this.currentAnimation.forcePlayOnce;
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

        IncreaseAnimationIndex(spriteSheet);
        AssingNextTexture(spriteSheet);

        this.currentFrameTime = 0.0f;
    }

    private void IncreaseAnimationIndex(List<Sprite> spriteSheet) {
        this.currentAnimationIndex++;

        if (this.currentAnimationIndex >= spriteSheet.Count) {
            this.isOnForcePlay = false;
            this.currentAnimationIndex = this.currentAnimationIndex % spriteSheet.Count;
        }
    }

    private void AssingNextTexture(List<Sprite> spriteSheet) {
        Sprite sprite = spriteSheet[this.currentAnimationIndex];
        Texture texture = this.GetTextureOfSprite(sprite);
        this.meshRenderer.material.mainTexture = texture;
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

    private void SetFlipHorizontal(bool flip) {
        Vector2 scale = new Vector2(1, 1);

        if (flip) {
            scale = new Vector2(-1, 1);
        }

        this.meshRenderer.material.SetTextureScale("_MainTex", scale);
    }
}
